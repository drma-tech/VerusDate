using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Helper;

namespace VerusDate.Shared.ViewModel
{
    [Table("Gamification")]
    public class GamificationVM : ViewModelType
    {
        [Computed]
        private static int MaxLevelXP => 100;

        [Computed]
        public int MaxFood => Level == 0 ? 0 : Level * 20;

        /// <summary>
        /// Use for API
        /// </summary>
        public GamificationVM()
        {
        }

        /// <summary>
        /// Use for insert
        /// </summary>
        /// <param name="id"></param>
        public GamificationVM(string id)
        {
            Id = id;
        }

        [ExplicitKey]
        public string Id { get; set; }

        [Display(Name = "XP")]
        public int XP { get; set; } = 0;

        [Display(Name = "Level")]
        public int Level { get; set; } = 1;

        [Display(Name = "Diamond")]
        public int Diamond { get; set; } = 0;

        [Display(Name = "Food")]
        public int Food { get; set; } = 20;

        public void AddXP(int qtd)
        {
            if (XP + qtd >= MaxLevelXP) //se passar de 100, sobe um nivel
            {
                AddLevel();
                XP = XP + qtd - MaxLevelXP;
            }
            else
            {
                XP += qtd;
            }
        }

        public void RemoveXP(int qtd)
        {
            var NovoXP = XP - qtd;

            if (Level <= 1) //LEVEL 1
            {
                if (NovoXP >= 0)
                {
                    XP = NovoXP;
                }
                else
                {
                    XP = 0;
                }
            }
            else //LEVEL 2 EM DIANTE
            {
                if (NovoXP >= 0)
                {
                    XP = NovoXP;
                }
                else
                {
                    RemoveLevel();
                    XP = MaxLevelXP + NovoXP;
                }
            }
        }

        private void AddLevel(int qtd = 1)
        {
            Level += qtd;
        }

        private void RemoveLevel(int qtd = 1)
        {
            var NovoLevel = Level - qtd;

            if (NovoLevel <= 1)
            {
                Level = 1;
            }
            else
            {
                Level -= qtd;
            }
        }

        public void AddDiamond(int qtd)
        {
            Diamond += qtd;
        }

        public void RemoveDiamond(int qtd = 1)
        {
            if (Diamond == 0) throw new NotificationException("Diamantes insuficientes");

            Diamond -= qtd;
        }

        public void ExchangeFood(int qtdDiamond = 1)
        {
            var NewFood = qtdDiamond * 10;

            RemoveDiamond(qtdDiamond);

            if (Food + NewFood > MaxFood)
            {
                throw new NotificationException("Limite máximo de maças alcançado para seu nível");
            }

            Food += NewFood;
        }

        public void RemoveFood(int qtd = 1)
        {
            if (Food == 0) throw new NotificationException("Maças insuficientes");

            Food -= qtd;
        }
    }
}