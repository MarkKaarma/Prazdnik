using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Prazdnik
{
    public partial class MainPage : CarouselPage
    {
        List<string> friends, mail, sms, celebrate; // Создается список

        private void swith_Toggled(object sender, ToggledEventArgs e) // Для свитчера. Если нажат, то будет отправка СМС-ом, а если нет - почта.
        {
            if (swith.IsToggled == true)
            {
                textis.Text = "СМС";
            }
            else
            {
                textis.Text = "Почтой";
            }
        }
        public MainPage()
        {
            InitializeComponent();
            friends = new List<string>() { "Момо", "Марк", "Карим" }; // Имена наших рабов :)
            sms = new List<string>() { "53316943", "8800555355", "1231311124124" }; // Номер телефона
            mail = new List<string> { "mark.kaarma@gmail.com", "tormoplayyt@gmail.com", "momo.jest@gmail.com" }; // Пишем сюда почты
            celebrate = new List<string> { "С днем рождения!", "С Рождеством", "Просто поздравляю тебя" }; // Офомляемся здесь поздравления
            friend.ItemsSource = friends; 
            friend.SelectedIndexChanged += Friend_SelectedIndexChanged;
            btn.Clicked += Btn_Clicked;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            Random random = new Random(); // Создается рандом поздравления при отправке, если будет выбран друг
            int rand = random.Next(3);
            if (swith.IsToggled == true)
            {
                await Sms.ComposeAsync(new SmsMessage { Body = celebrate[rand], Recipients = new List<string> { sms[friend.SelectedIndex] } });
                
            }
            else
            {
                await Email.ComposeAsync("Поздравление", celebrate[rand], mail[friend.SelectedIndex]);
               
            }
        }

        private void Friend_SelectedIndexChanged(object sender, EventArgs e)
        {
            emaile.Text = mail[friend.SelectedIndex];
            telefone.Text = sms[friend.SelectedIndex];
        }
        private void restbtn_Clicked(object sender, EventArgs e) // Можно выбрать рандомно  поздравление при помощи кнопки и потом отправить на почту/СМС.
        {
            Random random = new Random();
            int raand = random.Next(3);
            rando.Text = celebrate[raand];
        }
    }
}
