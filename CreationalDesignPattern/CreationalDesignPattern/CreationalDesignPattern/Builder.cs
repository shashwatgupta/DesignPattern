using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalDesignPattern
{
    class Builder
    {
        public static void Run()
        {
            USAddressBuilder ab = new USAddressBuilder();
            Director dt = new Director();
            dt.BuildAddress(ab);
            ab.GetUsAddress();

            IndiaAddressBuilder abi = new IndiaAddressBuilder();
            dt.BuildAddress(abi);
            abi.GetIndiaAddress();
        }


        public class Director
        {
            public AddressBuilder BuildAddress(AddressBuilder ab)
            {
                ab.SetHomeOwner("Shashwat Gupta");
                ab.SetPin("100");
                ab.SetHomeType(true);
                ab.SetHomeOtherDetails("200", "MyStreet", "NewCity", "NewState");
                return ab;
            }
        }


        public class AddressBuilder
        {

            public void SetPin(string pinId) { _pinId = pinId; }
            public virtual void SetHomeOwner(string Name)
            {
                // this is intentionally empty
            }

            public virtual void SetHomeOtherDetails(string homeNumber, string streetName, string City, string state)
            {
                // this is intentionally empty
            }

            public void SetHomeType(bool isSharedProperty)
            {
                // this is intentionally empty
            }

            protected string _pinId;


        }


        public class USAddressBuilder : AddressBuilder
        {
            public override void SetHomeOtherDetails(string homeNumber, string streetName, string City, string state)
            {
                address = address + homeNumber + "," + streetName + "," + City + "," + state;
            }

            public USAddress GetUsAddress()
            {

                return new USAddress(address, _pinId);
            }

            private string address=string.Empty;
        }

        public class IndiaAddressBuilder : AddressBuilder
        {
            public override void SetHomeOwner(string Name)
            {
                this._homeOwner = Name;
            }

            public override void SetHomeOtherDetails(string homeNumber, string streetName, string City, string state)
            {
                address = address + homeNumber + "," + streetName ;
            }

            public IndiaAddress GetIndiaAddress()
            {

                return new IndiaAddress(_homeOwner, address, _pinId);
            }

            private string address = string.Empty;
            private string _homeOwner;
        }


        /// <summary>
        /// The USAddress and IndiaAddres represents the product and they need not to share the the same type/Interface.
        /// </summary>
        public class USAddress
        {
            public  USAddress(string address ,string zip)
            {
                this.address = address;
                this.zip = zip;
            }
            public string address;
            public string zip;
        }

        public class IndiaAddress
        {
            public IndiaAddress(string homeOwner, string address, string pin)
            {
                this.homeOwner = homeOwner;
                this.address = address;
                this.pin = pin;
            }
            public string homeOwner;
            public string address;
            public string pin;
        }
    }

}
