using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISPharmacy
{
    public class Copier
    {
        public static void ObjectCoppier(object parent, object child)
        {
            List<string> lstNotToCopy = new List<string>();
            lstNotToCopy.Add("CreatorUserId");
            lstNotToCopy.Add("CreationTime");
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    try
                    {
                        if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType && childProperty.CanWrite)
                        {
                            if (!lstNotToCopy.Contains(parentProperty.Name))
                                childProperty.SetValue(child, parentProperty.GetValue(parent));
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }

                }
            }
        }
    }
}
