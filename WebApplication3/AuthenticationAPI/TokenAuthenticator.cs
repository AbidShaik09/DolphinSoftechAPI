using AuthenticationAPI.Controllers;
using AuthenticationAPI.Model;

namespace AuthenticationAPI
{
    public class TokenAuthenticator
    {

        public bool Authenticate(Client client)
        {

            string accessToken = decode(client.accessToken);
            string[] userToken = accessToken.Split("validTill");
            if (userToken.Length < 2)
            {
                return false;
            }
            DateTime t = DateTime.Parse(userToken[1]);
            if ( client.username==userToken[0] && t >= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public Client GenerateAuthToken(LoginPattern user)
        {
            Client client = new Client();
            DateTime d = DateTime.Now;
            d = d.AddHours(6);

            string accessToken = user.username + "validTill" + (d);
            accessToken = "accessToken:" + encode(accessToken);
            client.accessToken = accessToken;
            client.username= user.username;
            return client;
        }

        public string encode(string raw)
        {
            char[] chars = raw.ToCharArray();

            string s = "";
            for (int i = 0; i < chars.Length; i++)
            {
                if (i % 2 == 0)
                {
                    chars[i] = (char)(chars[i] + 21);
                }
                else
                {

                    chars[i] = (char)(chars[i] + 80);
                }
                s += chars[i];

            }
            return s;

        }
        public string decode(string raw)
        {
            try
            {
                char[] chars = raw.Split(':')[1].ToCharArray();
                string s = "";

                for (int i = 0; i < chars.Length; i++)
                {


                    if (i % 2 == 0)
                    {
                        chars[i] = (char)(chars[i] - 21);
                    }
                    else
                    {
                        chars[i] = (char)(chars[i] - 80);
                    }
                    s += chars[i];

                }
                return s;
            }
            catch (Exception e)
            {
                return "Invalid Token";
            }
        }
    }
}
