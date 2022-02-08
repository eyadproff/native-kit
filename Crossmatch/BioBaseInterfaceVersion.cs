namespace Crossmatch
{
    public class BioBaseInterfaceVersion
    {
        public int Major { get; private set; }
       
        public int Minor { get; private set; }

        public BioBaseInterfaceVersion(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }
    }
}
