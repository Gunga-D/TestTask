using UnityEngine.UI;
using UnityEngine;

namespace Client
{
    public abstract class InputIntForm : MonoBehaviour
    {
        private Text _inputText;

        protected void Initialize(Text inputText)
        {
            _inputText = inputText;
        }

        public int GetValue()
        {
            int result = 0;

            int.TryParse(_inputText.text, out result);

            return result;
        }
    }
}
