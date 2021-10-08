namespace AccelerateBall.Model
{
    public class Dict
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public int Percentage { get; set; }


        public Dict()
        {
        }

        public Dict(string code, string name, decimal value, int percentage)
        {
            Code = code;
            Name = name;
            Value = value;
            Percentage = percentage;
        }
    }
}
