using System.IO;
using System.Web.Hosting;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.General;
using Newtonsoft.Json;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class ContactService : IContactService
    {
        public Contact Get()
        {
            Contact contact;

            CheckFile();

            using (var sr = new StreamReader(HostingEnvironment.ApplicationPhysicalPath + "\\Data\\contact.json"))
            {
                var json = sr.ReadToEnd();
                contact = JsonConvert.DeserializeObject<Contact>(json);
            }

            return contact ?? new Contact();
        }

        public void Update(Contact contact)
        {
            CheckFile();

            using (var sr = new StreamWriter(HostingEnvironment.ApplicationPhysicalPath + "\\Data\\contact.json"))
            {
                var json = JsonConvert.SerializeObject(contact);
                sr.Write(json);
            }
        }

        private void CheckFile()
        {
            if (!File.Exists(HostingEnvironment.ApplicationPhysicalPath + "\\Data\\contact.json"))
            {
                var file = File.Create(HostingEnvironment.ApplicationPhysicalPath + "\\Data\\contact.json");
                file.Close();
            }
        }
    }
}