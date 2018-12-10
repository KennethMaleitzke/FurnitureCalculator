using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_SimpleMonsterClasses
{
    public class FurnitureItems
    {
        public enum ConditionOfFurniture
        {
            Good,
            Okay,
            Bad
        }

        #region FIELDS
        private string _nameOfItem;
        private double _weight;
        private ConditionOfFurniture _currentCondition;
        private double _value;
        private string _room;













        #endregion

        #region PROPTERTIES
        public string NameOfItem
        {
            get { return _nameOfItem; }
            set { _nameOfItem = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
   
        public ConditionOfFurniture CurrentCondition
        {
            get { return _currentCondition; }
            set { _currentCondition = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public FurnitureItems()
        {

        }

        public FurnitureItems(string name)
        {
            _nameOfItem = name;
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Room
        {
            get { return _room; }
            set { _room = value; }
        }
        #endregion

        #region METHODS

        public string CurrentConditionInfo()
        {
            return "The " + _nameOfItem + " is in " + _currentCondition + " condition.";
        }

        #endregion
    }
}
