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
using TimeSpendForm.Services;

namespace TimeSpendForm.Forms
{
    public partial class frmMain : Form
    {
        private Form _frmPersonalKey;
        private HttpClient _client;
        private string _personalKey;
        private List<Issue> _IssueList;
        Dictionary<string, int> _description;
        private ILogWorkService _logWorkService;


        public frmMain(Form frmPersonalKey)
        {
            this._frmPersonalKey = frmPersonalKey;
            this._client = new HttpClient();
            this._IssueList = new List<Issue>();
            this._description = new Dictionary<string, int>();
            this._personalKey = File.ReadAllText(@"C:\temp\Personalkey.txt").Trim();
            this._logWorkService = new LogWorkService(new());

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
            var path = String.Format("https://gitlab.com/api/v4/projects/{0}/issues?per_page=100&state=opened", projectId);
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

        private string ValidateForm()
        {
            var projectId = Convert.ToInt32(ddProject.SelectedValue);
            var issueId = Convert.ToInt32(ddCard.SelectedValue);
            var noteId = Convert.ToInt32(ddDescription.SelectedValue);
            var noteDescription = tbDescricao.Text;
            var hour = qtdHora.Value;
            var minute = qtdMinuto.Value;

            if (projectId == 0)
                return "Selecione um projeto!";

            if (issueId == 0)
                return "Selecione um card!";

            if (noteId == 0)
                return "Selecione um apontamento!";

            if ((noteId == 10 || noteId == 11 || noteId == 13) && string.IsNullOrEmpty(noteDescription.Trim()))
                return "Informe uma descrição!";

            if (hour == 0 && minute == 0)
                return "Informe a quantidade de horas/minuto!";

            return string.Empty;
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ValidateForm()))
            {
                MessageBox.Show(ValidateForm());
                return;
            }
            var uri = $"https://gitlab.com/api/v4/projects/{Convert.ToInt32(ddProject.SelectedValue)}/issues/{Convert.ToInt32(ddCard.SelectedValue)}/notes";
            LogWork logWork = new()
            {
                Url = uri,
                Note = new()
                {
                    body = string.IsNullOrEmpty(tbDescricao.Text.Trim())
                                    ? $"/spend {SetTime()} \n {ddDescription.Text}"
                                    : $"/spend {SetTime()} \n {ddDescription.Text} {tbDescricao.Text.Trim()}",
                    issue_iid = Convert.ToInt32(ddCard.SelectedValue)
                },
                PersonalToken = _personalKey
            };

            if (await _logWorkService.NewLogWork(logWork))
            {
                MessageBox.Show("LogWork realizado com sucesso!");
                qtdHora.Value = 0;
                qtdMinuto.Value = 0;
                ddProject.SelectedIndex = 0;
                ddDescription.SelectedIndex = 0;
                tbDescricao.Text = "";
            }
            else
                MessageBox.Show("LogWork não realizado!");
        }


        private string SetTime()
        {
            var hour = Convert.ToInt32(qtdHora.Value);
            var minute = Convert.ToInt32(qtdMinuto.Value);

            var setTime = "";
            if (hour > 0 && minute > 0)
                setTime = string.Format("{0}h {1}m", hour, minute);
            else if (hour > 0 && minute == 0)
                setTime = string.Format("{0}h", hour);
            else if (minute > 0 && hour == 0)
                setTime = string.Format("{0}m", minute);

            return setTime;
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
                var projectId = Convert.ToInt32(ddProject.SelectedValue);
                //var myEnum = (int)Enum.Parse(typeof(ProjectsEnum), ddProject.SelectedValue.ToString());
                GetIssues(projectId);
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
