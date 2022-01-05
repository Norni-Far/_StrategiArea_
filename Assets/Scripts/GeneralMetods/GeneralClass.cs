using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralMetods
{
    class GeneralClass
    {
        /// <summary>
        /// Вызывает анимацию у объекта (int)
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="NameAnimation"></param>
        /// <param name="NumberOfPlay">Цифра для переключения анимации</param>
        public void PlayAnimations(GameObject gameObject, string NameAnimation, int NumberOfPlay)
        {
            gameObject.GetComponent<Animator>().SetInteger(NameAnimation, NumberOfPlay);
        }

        /// <summary>
        /// Вызывает анимацию у объекта (bool)
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="NameAnimation"></param>
        /// <param name="NumberOfPlay">Цифра для переключения анимации</param>
        public void PlayAnimations(GameObject gameObject, string NameAnimation, bool BoolOfPlay)
        {
            gameObject.GetComponent<Animator>().SetBool(NameAnimation, BoolOfPlay);
        }
    }
}
