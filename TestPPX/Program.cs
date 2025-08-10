using PPX_Pos;

namespace TestPPX
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create base POS implementation
            var basePOS = new PassportX_POS();

            // Decorate it with customer-specific functionality
            var customerPOS = new CustomerPOS(basePOS, "Israel");
            
            // Note: "Israel" can also be read from appsettings.json or environment variables 
            //       for easier configuration without changing the code.

            POS_Process.Load(customerPOS);
        }
    }
}
