using Humanizer.DateTimeHumanizeStrategy;
using Microsoft.Data.SqlClient.DataClassification;

using GCommon.ExtensionMethods;

namespace GCommon.Models
{
    /// <summary>
    /// как ще изглежда страницата с обяви
    /// </summary>
    public class AdsPersonViewModel
    {
        public required int DeclareWorkerFreeID { get; set; }

       
       

        public required string FName { get; init; }
        public required string LName { get; init; }

        public required string Phone { get; init; }

        public required string Email { get; init; }

        public required string DayName { get; init; }

        public required int Hour { get; init; }

        public required int Minute { get; init; }

        public required string AdvText { get; init; }

        public required string AdvTitle { get; init; }

        public required decimal Price { get; init; } = 0;

        public required string TaxWage { get; init; }

        public required string Photo { get; init; }

        public required string WorkCategory { get; init; }
        //********************************************************************************************
        /// <summary>
        /// кой извършва работата
        /// </summary>
        /// <returns></returns>
        public string FullName()
        {
            return this.FName.IncludeLastName(this.LName);
        }
        //********************************************************************************************
        /// <summary>
        /// какво прави и за колко пари
        /// </summary>
        /// <returns></returns>
        public string WhatToDo()
        {
            return this.WorkCategory.IncludeTaxPrint(this.TaxWage,this.Price);
                 
        }

        //********************************************************************************************
        /// <summary>
        /// показва за кой ден винаги е свободен за оглед
        /// </summary>
        /// <returns></returns>
        public string EveryDay()
        {

            return $"{this.DayName} - {this.Hour.PrintableHour(this.Minute)}";
                
        }
        //********************************************************************************************
    }



}
