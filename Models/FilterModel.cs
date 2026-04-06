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
        private bool AnyResult()
        {
            return this.TotalPages > 0;
        }
        //******************************************************************************************
        public int[] XPage()
        {
            /*
             * ключови думи за тест
             * празен текст - страници 7
             * word - страници 3
             * dsfsdfsdfds - няма страници
             * бойл - страници 1
             * пок - страници 2
             * 
             * 
             */
            List<int> result = new List<int>();

            int max_page_count = 3;
           



            if (this.TotalPages > max_page_count)
            {
                if ((this.TotalPages - this.CurrentPage + 1) >= max_page_count)
                {
                    for (int i = 1; i <= max_page_count; i++)
                    {
                        result.Add(i + this.CurrentPage - 1);
                    }
                }
                else
                {

                    /*
                     * разполагаме с поне 4 страници
                     * случаите са 
                     * 1-2-3
                     * 2-3-4 - тук трябва да е край
                     * 3-4-изход - това не трябва да се хваща
                     * -------------------
                     * (4 - 3 + 1 = 2) >= 3 - false
                     * (4 - 4 + 1 = 1) >= 3 - false
                     */
                    //вадим последните max_page_count страници

                    for (int i = (this.TotalPages - max_page_count+1); i <= this.TotalPages; i++)
                    {
                        result.Add(i);
                    }
                }
            }
            else
            {
                /*
                 *  нямаме минималното количество страници за странициране
                 *  затова работим с максималния брой
                 */

                for (int i = 1; i <= this.TotalPages; i++)
                {
                    result.Add(i);
                }
            }






            return result.ToArray();
        }
        

        //******************************************************************************************

        public void Validate()
        {
            if (this.AnyResult())
            {
                if (this.CurrentPage > this.TotalPages) this.CurrentPage = this.TotalPages;
                if (this.CurrentPage < 1) this.CurrentPage = this.min_page;//За да ти тръгне заявката
            }
            
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
