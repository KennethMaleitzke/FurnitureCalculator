using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_SimpleMonsterClasses
{
    public class SeaMonster
    {
        public enum EmotionalState
        {
            happy,
            sad,
            angry
        }

        #region FIELDS
        private string _name;
        private double _weight;
        private bool _canUseFreshWater;
        private EmotionalState _currentEmotionalState;
        private string _homeSea;







        #endregion

        #region PROPTERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public bool CanUseFreshWater
        {
            get { return _canUseFreshWater; }
            set { _canUseFreshWater = value; }
        }
   
        public EmotionalState CurrentEmotionalState
        {
            get { return _currentEmotionalState; }
            set { _currentEmotionalState = value; }
        }

        public string HomeSea
        {
            get { return _homeSea; }
            set { _homeSea = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public SeaMonster()
        {

        }

        public SeaMonster(string name)
        {
            _name = name;
        }

        #endregion

        #region METHODS

        public string CurrentEmotionInfo()
        {
            return _name + " is " + _currentEmotionalState + ".";
        }

        #endregion
    }
}
