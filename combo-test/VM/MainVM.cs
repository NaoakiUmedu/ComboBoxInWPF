using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace combo_test.VM
{
    internal class MainVM
    {
        /// <summary>
        /// もこもこ1匹分の情報
        /// </summary>
        internal class Mokomoko : INotifyPropertyChanged
        {
            /// <summary>
            /// 名前
            /// </summary>
            public string Name
            {
                get { return name; }
                set { this.SetProperty(ref this.name, value); }
            }
            private string name = string.Empty;
            /// <summary>
            /// 種類
            /// </summary>
            public string MokoType
            {
                get { return this.mokoType; }
                set { this.SetProperty(ref this.mokoType, value); }
            }
            private string mokoType = string.Empty;


            public event PropertyChangedEventHandler? PropertyChanged;
            private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
            {
                field = value;
                var h = this.PropertyChanged;
                if (h != null)
                {
                    h(this, new PropertyChangedEventArgs(propertyName));
                }
            }


        }

       
        /// <summary>
        /// もこもこたち
        /// </summary>
        public ObservableCollection<Mokomoko> Mokomokos { get; set; }
        /// <summary>
        /// もこもこの種類
        /// <!-- かんどころ(4) ここに{get; set;}がないとダメ！ -->
        /// </summary>
        public static ObservableCollection<string> MokoTypeList { get; set; } = new()
        {
            "しばちゃん",
            "たぬちゃん",
            "こんちゃん",
            "あきたちゃん",
            "はすきーちゃん"
        };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainVM()
        {
            this.Mokomokos = new ObservableCollection<Mokomoko>();
            Mokomokos.Add(new Mokomoko() { Name = "ぽん太" });
            Mokomokos.Add(new Mokomoko() { Name = "こん太" });
        }

    }
}
