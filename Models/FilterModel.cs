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



        public int[] XPage()
        {
            List<int> result = new List<int>();
            int max_page_count = 3;
            if (this.CurrentPage + max_page_count - 1 <= this.TotalPages)
            {
                for (int i = this.CurrentPage; i <= this.CurrentPage + max_page_count - 1; i++)
                {
                    result.Add(i);

                }


            }
            else
            {
                for (int i = this.TotalPages - max_page_count + 1; i <= this.TotalPages; i++)
                {
                    result.Add(i);

                }
            }
            return result.ToArray();

        }
             

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
