namespace currency.marshallzehr.model
{
    public class Operation
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Message}";
        }
    }

    public class OperationTerm : Operation 
    {
        public bool NeedEntry { get; set; }
    }

   




}
