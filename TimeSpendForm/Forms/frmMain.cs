using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeSpendForm.Core;
using TimeSpendForm.Models;

namespace TimeSpendForm.Forms
{
    public partial class frmMain : Form
    {
        private Form _frmPersonalKey;
        private HttpClient _client;
        private string _personalKey;
        private List<Issue> _IssueList;
        Dictionary<string, int> _description;

        public frmMain(Form frmPersonalKey)
        {
            this._frmPersonalKey = frmPersonalKey;
            this._client = new HttpClient();
            this._IssueList = new List<Issue>();
            this._description = new Dictionary<string, int>();
            this._personalKey = File.ReadAllText(@"C:\temp\Personalkey.txt");
            InitializeComponent();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._frmPersonalKey.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();
            this.ddProject.DataSource = Enum.GetValues(typeof(ProjectsEnum));
            this.tbDescricao.Hide();
            this.lbDescricaoNote.Hide();
            this.tbDescricao.Text = "";
            loadDescription();
        }

        public async void GetIssues(int projectId)
        {
            List<Issue> result = new List<Issue>();
            this._IssueList = new List<Issue>();
            this._client = new HttpClient();

            var path = String.Format("https://gitlab.com/api/v4//projects/{0}/issues?per_page=100&state=opened", projectId);
            _client.BaseAddress = new Uri(path);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", _personalKey);

            HttpResponseMessage response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<List<Issue>>();

            foreach (var item in result)
            {
                this._IssueList.Add(new Issue()
                {
                    title = String.Format("{0} - {1}", item.iid, item.title),
                    iid = item.iid
                });
            }

            ddCard.DataSource = this._IssueList.OrderBy(x => x.iid).ToList();
            ddCard.DisplayMember = "title";
            ddCard.ValueMember = "iid";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            var projectId = Convert.ToInt32(ddProject.SelectedValue);
            var issueId = Convert.ToInt32(ddCard.SelectedValue);
            var noteId = Convert.ToInt32(ddDescription.SelectedValue);
            var noteDescription = tbDescricao.Text;
            var hour = qtdHora.Value;
            var minute = qtdMinuto.Value;

            if (projectId == 0)
            {
                MessageBox.Show("Selecione um projeto!");
                return;
            }

            if (issueId == 0)
            {
                MessageBox.Show("Selecione um card!");
                return;
            }

            if (noteId == 0)
            {
                MessageBox.Show("Selecione um apontamento!");
                return;
            }

            if ((noteId == 10 || noteId == 11 || noteId == 13) && string.IsNullOrEmpty(noteDescription.Trim()))
            {
                MessageBox.Show("Informe uma descrição!");
                return;
            }

            if(hour == 0 && minute == 0)
            {
                MessageBox.Show("Informe a quantidade de horas/minuto!");
                return;
            }

            var setTime = "";
            if (hour > 0 && minute > 0)
                setTime = string.Format("{0}h {1}m", hour, minute);
            else if (hour > 0 && minute == 0)
                setTime = string.Format("{0}h", hour);
            else if (minute > 0 && hour == 0)
                setTime = string.Format("{0}m", minute);

            var bodyDescription = "";
            if (string.IsNullOrEmpty(noteDescription.Trim()))
                bodyDescription = string.Format("/spend {0} \n {1}", setTime, ddDescription.Text);
            else
                bodyDescription = string.Format("/spend {0} \n {1} {2}", setTime, ddDescription.Text, noteDescription);

            Note noteObject = new Note()
            {
                body = bodyDescription,
                issue_iid = issueId
            };

            var httpRequest = (HttpWebRequest)WebRequest.Create(String.Format("https://gitlab.com/api/v4/projects/{0}/issues/{1}/notes", projectId, issueId));
            httpRequest.Method = "POST";
            httpRequest.Accept = "application/json";
            httpRequest.Headers["PRIVATE-TOKEN"] = _personalKey;
            httpRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(noteObject));
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

        }

        private void loadDescription()
        {
            _description.Add("Selecione", 0);
            _description.Add("1. Briefing/Kick-off", 1);
            _description.Add("2. Análise de negócio", 2);
            _description.Add("3. Análise técnica", 3);
            _description.Add("4. Validação técnica", 4);
            _description.Add("5. Desenvolvimento", 5);
            _description.Add("6. Correção / Ajustes", 6);
            _description.Add("7. Homologação", 7);
            _description.Add("8. Validação de Negócio", 8);
            _description.Add("9. Implantação", 9);
            _description.Add("10. Suporte ticket", 10);
            _description.Add("11. Suporte ticket", 11);
            _description.Add("12. Daily", 12);
            _description.Add("13. Reunião", 13);

            ddDescription.DataSource = new BindingSource(_description, null);
            ddDescription.DisplayMember = "Key";
            ddDescription.ValueMember = "Value";
        }

        private void ddProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddProject.SelectedIndex != 0)
            {
                var myEnum = (int)Enum.Parse(typeof(ProjectsEnum), ddProject.SelectedValue.ToString());
                GetIssues(myEnum);
            }
            else
            {
                ddCard.DataSource = new List<Issue>() { new Issue() { title = "Selecione", iid = 0 } };
                ddCard.DisplayMember = "title";
                ddCard.ValueMember = "iid";
            }
        }

        private void ddDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddDescription.SelectedIndex == 10 || ddDescription.SelectedIndex == 11 || ddDescription.SelectedIndex == 13)
            {
                this.tbDescricao.Show();
                this.lbDescricaoNote.Show();
                this.tbDescricao.Text = "";
            }
            else
            {
                this.tbDescricao.Hide();
                this.lbDescricaoNote.Hide();
                this.tbDescricao.Text = "";
            }
        }

    }
}
