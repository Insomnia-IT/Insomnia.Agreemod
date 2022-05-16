using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insomnia.Agreemod.Data.Enums
{
    public enum FoodType
    {
        /// <summary>
        /// Полностью бесплатное питание.
        /// </summary>
        Free,
        /// <summary>
        /// Питание при котором необходимо оплачивать половину стоимости.
        /// </summary>
        Discount50,
        /// <summary>
        /// Если нет данных, питание с 100% оплатой или вообще не кормят.
        /// </summary>
        Empty
    }
}
