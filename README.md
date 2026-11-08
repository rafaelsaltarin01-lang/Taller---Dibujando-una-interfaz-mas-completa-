# MiPresentacion

Aplicación de escritorio desarrollada con **Avalonia UI 11** y C# (.NET 8). Permite ingresar nombre, apellido y edad en un formulario y mostrar una presentación personalizada al presionar un botón.

## Descripción

El usuario llena tres campos de texto y presiona **Presentarme**. La aplicación valida los datos y muestra un mensaje personalizado (en verde) o una advertencia (en rojo). El botón **Limpiar** restablece el formulario y el botón **Cambiar saludo** (reto adicional) alterna entre un saludo informal y uno formal sin reiniciar la aplicación.

## Controles utilizados

| Control | x:Name | Función |
|---|---|---|
| `TextBlock` | — | Título «Mi primera aplicación gráfica» |
| `TextBox` | `TxtNombre` | Entrada del nombre |
| `TextBox` | `TxtApellido` | Entrada del apellido |
| `TextBox` | `TxtEdad` | Entrada de la edad |
| `Button` | `BtnPresentarme` | Valida y muestra la presentación |
| `Button` | `BtnLimpiar` | Vacía los campos y restaura el mensaje inicial |
| `Button` | `BtnCambiarSaludo` | Alterna entre dos saludos (reto adicional) |
| `TextBlock` | `TxtResultado` | Muestra el resultado o la advertencia |
| `StackPanel` | — | Organiza los controles con `Margin` y `Spacing` |

## Funcionamiento de los eventos

- **BtnPresentarme_Click**: lee los textos de los `TextBox`, comprueba que nombre y apellido no estén vacíos ni solo con espacios (`string.IsNullOrWhiteSpace`), verifica la edad con `int.TryParse()` y que sea mayor que cero. Si todo es válido arma el mensaje; si no, muestra una advertencia.
- **BtnLimpiar_Click**: pone los tres campos en vacío, restaura el mensaje inicial y llama a `TxtNombre.Focus()`.
- **BtnCambiarSaludo_Click**: cambia una variable booleana que decide cuál de los dos saludos se muestra y actualiza el mensaje al instante.

## Casos de prueba

| Caso | Datos | Resultado esperado | Resultado |
|---|---|---|---|
| 1 | Nombre, apellido y edad válidos | Muestra la presentación | ✔ |
| 2 | Nombre vacío | Advertencia | ✔ |
| 3 | Apellido vacío | Advertencia | ✔ |
| 4 | Edad con letras | Solicita edad numérica | ✔ |
| 5 | Edad negativa o 0 | Rechaza la edad | ✔ |
| 6 | Presionar Limpiar | Restablece el formulario | ✔ |

## Cómo ejecutar

Requisitos: [.NET 8 SDK](https://dotnet.microsoft.com/download).

```bash
git clone <URL-DEL-REPOSITORIO>
cd MiPresentacion
dotnet run
```


## Pregunta de reflexión

**¿Cuál es la función de MainWindow.axaml y MainWindow.axaml.cs, y cómo se relacionan mediante x:Name y los eventos Click?**

> Escribe aquí tu respuesta con tus propias palabras. Ideas para guiarte:
> - `MainWindow.axaml` define *cómo se ve* la ventana (controles, orden, márgenes).
> - `MainWindow.axaml.cs` define *qué hace* la ventana (la lógica en C#).
> - `x:Name` le da un nombre a un control para poder usarlo desde C# (por ejemplo `TxtNombre.Text`).
> - `Click="BtnPresentarme_Click"` conecta el botón con el método de C# que se ejecuta al presionarlo.
