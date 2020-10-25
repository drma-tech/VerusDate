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
        private static int MaxRankXP => 100;

        [Computed]
        private static int MaxRankFood => 20;

        [Computed]
        public int MaxFood => Rank == 0 ? MaxRankFood : Rank * MaxRankFood;

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

        [Display(Name = "Rank")]
        public int Rank { get; set; } = 1;

        [Display(Name = "XP")]
        public int XP { get; set; } = 0;

        [Display(Name = "Food")]
        public int Food { get; set; } = 20;

        [Display(Name = "Diamond")]
        public int Diamond { get; set; } = 1;

        public void AddXP(int qtd)
        {
            if (XP + qtd >= MaxRankXP) //se passar de 100, sobe um nivel
            {
                AddRank();
                XP = XP + qtd - MaxRankXP;
            }
            else
            {
                XP += qtd;
            }
        }

        public void RemoveXP(int qtd)
        {
            var NovoXP = XP - qtd;

            if (Rank <= 1) //RANK 1
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
            else //RANK 2 EM DIANTE
            {
                if (NovoXP >= 0)
                {
                    XP = NovoXP;
                }
                else
                {
                    RemoveRank();
                    XP = MaxRankXP + NovoXP;
                }
            }
        }

        private void AddRank(int qtd = 1)
        {
            Rank += qtd;
        }

        private void RemoveRank(int qtd = 1)
        {
            var NovoLevel = Rank - qtd;

            if (NovoLevel <= 1)
            {
                Rank = 1;
            }
            else
            {
                Rank -= qtd;
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