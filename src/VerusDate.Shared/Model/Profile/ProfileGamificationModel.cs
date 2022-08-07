﻿using VerusDate.Shared.Core;
using VerusDate.Shared.Helper;

namespace VerusDate.Shared.Model
{
    public class ProfileGamificationModel
    {
        private static int MaxRankXP => 100;

        private static int MaxRankFood => 20;

        [Custom(Name = "Ranking")]
        public int Ranking { get; set; }

        [Custom(Name = "XP")]
        public int XP { get; set; }

        [Custom(Name = "Food")]
        public int Food { get; set; }

        [Custom(Name = "Diamond")]
        public int Diamond { get; set; }

        public int GetMaxFood()
        {
            return Ranking == 0 ? MaxRankFood : Ranking * MaxRankFood;
        }

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

            if (Ranking <= 1) //RANK 1
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
            Ranking += qtd;
        }

        private void RemoveRank(int qtd = 1)
        {
            var NovoLevel = Ranking - qtd;

            if (NovoLevel <= 1)
            {
                Ranking = 1;
            }
            else
            {
                Ranking -= qtd;
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

            if (Food + NewFood > GetMaxFood())
            {
                throw new NotificationException("Limite máximo de maças alcançado para seu nível");
            }

            Food += NewFood;
        }

        public void ResetFood()
        {
            Food = GetMaxFood();
        }

        public void RemoveFood(int qtd = 1)
        {
            if (Food == 0) throw new NotificationException("Maças insuficientes");

            Food -= qtd;
        }
    }
}