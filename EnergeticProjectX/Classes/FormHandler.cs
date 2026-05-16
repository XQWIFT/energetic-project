using EnergeticProjectX.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс для взаимодействия между формами в приложении.
    /// </summary>
    public class FormHandler
    {
        /// <summary>
        /// Метод, который позволяет скрыть текущую форму и открыть новую.
        /// </summary>
        /// <param name="currentForm">Текущая форма.</param>
        /// <param name="nextForm">Новая форма.</param>
        public static void OpenForm(Form currentForm, Form nextForm)
        {
            Program.AppContext!.MainForm = nextForm;
            nextForm.Show();
            currentForm.Close();
        }

        /// <summary>
        /// Метод, который позволяет вернуться в форму авторизации при возникновении проблемы
        /// с обнаружением данных текущего пользователя системы.
        /// </summary>
        /// <param name="currentForm">Текущая форма.</param>
        public static void RedirectToAuthorization(Form currentForm)
        {
            var openForms = Application.OpenForms.Cast<Form>()
                .Where(f => f != currentForm)
                .ToList();

            foreach (var form in openForms)
            {
                form.Close();
            }

            var authorizationForm = Program.ServiceProvider.GetRequiredService<AuthorizationForm>();
            Program.AppContext!.MainForm = authorizationForm;
            authorizationForm.Show();
            currentForm.Close();
        }
    }
}