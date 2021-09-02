namespace AccelerateBall.Model
{
    public class Dict
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Percentage { get; set; }

        public Dict()
        {
        }

        public Dict(string code, string name, string percentage)
        {
            Code = code;
            Name = name;
            Percentage = percentage;
        }
    }
}
