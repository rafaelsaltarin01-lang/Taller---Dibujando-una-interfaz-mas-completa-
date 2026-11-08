using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace MiPresentacion;

public partial class MainWindow : Window
{
    private const string MensajeInicial = "Completa el formulario y presiona «Presentarme».";


    private bool _saludoFormal = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnPresentarme_Click(object? sender, RoutedEventArgs e)
    {
        string nombre = TxtNombre.Text?.Trim() ?? "";
        string apellido = TxtApellido.Text?.Trim() ?? "";
        string textoEdad = TxtEdad.Text?.Trim() ?? "";

        // Valida el nombre y apellido
        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
        {
            MostrarAdvertencia("⚠ El nombre y el apellido no pueden estar vacíos.");
            return;
        }

        // Valida la edad 
        if (!int.TryParse(textoEdad, out int edad))
        {
            MostrarAdvertencia("⚠ Por favor ingresa una edad numérica (número entero).");
            return;
        }

        if (edad <= 0)
        {
            MostrarAdvertencia("⚠ La edad debe ser un número entero positivo.");
            return;
        }

       
        TxtResultado.Foreground = Brushes.ForestGreen;

        if (_saludoFormal)
        {
            TxtResultado.Text =
                $"Buenos días. Me presento: {nombre} {apellido}, " +
                $"de {edad} años, estudiante de desarrollo de interfaces gráficas con C#.";
        }
        else
        {
            TxtResultado.Text =
                $"¡Hola! Mi nombre es {nombre} {apellido},\n" +
                $"tengo {edad} años y estoy aprendiendo\n" +
                "a desarrollar interfaces gráficas con C#.";
        }
    }

    private void BtnLimpiar_Click(object? sender, RoutedEventArgs e)
    {
        TxtNombre.Text = string.Empty;
        TxtApellido.Text = string.Empty;
        TxtEdad.Text = string.Empty;

        TxtResultado.Foreground = Brushes.Gray;
        TxtResultado.Text = MensajeInicial;

        TxtNombre.Focus();
    }

    private void BtnCambiarSaludo_Click(object? sender, RoutedEventArgs e)
    {
        _saludoFormal = !_saludoFormal;
        BtnCambiarSaludo.Content = _saludoFormal ? "Saludo: formal" : "Cambiar saludo";

      
        BtnPresentarme_Click(sender, e);
    }

    private void MostrarAdvertencia(string mensaje)
    {
        TxtResultado.Foreground = Brushes.Firebrick;
        TxtResultado.Text = mensaje;
    }
}
