using PPX_Pos;
namespace TestPPX
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default greeting (Hello)
            var Pos = new CustomerPOS("Israel");
            POS_Process.Load(Pos);

            // Or with custom greeting
            // var Pos = new CustomerPOS("Israel", "Shalom");


        }
    }
}