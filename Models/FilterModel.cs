using System.Configuration;

namespace GCommon.Models
{
    public class FilterModel
    {
        private int min_page = 1;
      

        public const int ElementsOnPage = 3;


        public required int TotalPages { get; set; } = 0;
        public required int CurrentPage { get; set; } = 0;

        public required string Keyword { get; set; } = string.Empty;

        //******************************************************************************************

        public void Validate()
        {
            if (this.CurrentPage > this.TotalPages) this.CurrentPage = this.TotalPages;
            if (this.CurrentPage < 1) this.CurrentPage = this.min_page;
        }
        //******************************************************************************************
        public int NextPage()
        {
            int result = this.CurrentPage + 1;
            if (result > this.TotalPages) result = this.TotalPages;
            return result;
        }
        //******************************************************************************************
        public int PreviousPage()
        {
            int result = this.CurrentPage - 1;
            if (result < this.min_page) result = this.min_page;
            return result;
        }
        //******************************************************************************************



    }
}
