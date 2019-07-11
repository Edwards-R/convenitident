using CoreLib.Core.Data;

namespace CoreLib.Core
{

    //Make class static to avoid having a connection per taxonomic identity
    static class Factory
    {
        private static Base connection = ResolveFactory();

        public static Base ResolveFactory()
        {
            return new SQLite("string");
        }
    }
}
