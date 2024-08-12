using CEntidades.Entidades;
using CLogica.Contracts;
using CLogica.Implementations;

namespace EjemploRepositorios
{
    public partial class Form1 : Form
    {
        private IAutorLogic _autorLogic;

        public Form1(IAutorLogic autorLogic)
        {
            _autorLogic = autorLogic;
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            List<Autor> examples = await _autorLogic.GetAll();
        }
    }
}
