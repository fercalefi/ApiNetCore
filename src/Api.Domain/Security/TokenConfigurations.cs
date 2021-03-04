namespace Api.Domain.Security
{
    public class TokenConfigurations
    {
        /*publico*/
        public string Audience { get; set; }
        /*emissor*/
        public string Issuer { get; set; }
        public int Seconds { get; set; }

    }
}