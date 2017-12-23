namespace DP.Domain.Samples.ChainOfResposibility
{
    public class ReceiverCn : IHandler
    {
        public IHandler Next { get; set; }

        public Content Action(string localization)
        {
            if (localization.Equals("zh-CN"))
            {
                var content =  new Content{
                    Country=DataFactory.CountryCn,
                    City=DataFactory.CityCn
                };
                System.Diagnostics.Debug.WriteLine($"{content.Country} {content.City}");
                return content;
            }
            else
                System.Diagnostics.Debug.WriteLine($"Not zh-CN, go to next receiver...");
            
            #region Do next
            if (this.Next == null) //Set a default next receiver
                this.Next = new ReceiverEn();

            return this.Next.Action(localization);
            #endregion
        }
    }
}