namespace WebApplication6.Models
{
    public class InsertAdverttisementToWorker
    {
        public required int? ID { get; set; }

        public required int WorkerID { get; set; }

        public required string? AdvText { get; set; }


        public static InsertAdverttisementToWorker Empty(int worker_id)
        {
            InsertAdverttisementToWorker result = new InsertAdverttisementToWorker()
            {
                ID = null,
                AdvText = string.Empty,
                WorkerID = worker_id,

            };
            return result;
        }

    }
}
