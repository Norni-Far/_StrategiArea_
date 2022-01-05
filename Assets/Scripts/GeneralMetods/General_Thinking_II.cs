using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace GeneralThinking
{

    public class General_Thinking_II : MonoBehaviour
    {

        // Flags
        public float DistanceForFlags = 8;    //  для выхода на ноль  опастности (расстояние от центра к границам)
        // 

        // Warning // секция уровня опатсности путей на рельсах, в зависимости от расстояния флага и поездов на этих путях
        public int[] WarningSections = new int[5];
        public int SrednieArifm = 0;

        public int[] LevelOFWarning = new int[5];
        public int[] Desijion = new int[5];
        //

        public void StandarttThink(Transform[] Flags, List<GameObject> TrainOn_1_line, List<GameObject> TrainOn_2_line,
            List<GameObject> TrainOn_3_line, List<GameObject> TrainOn_4_line, List<GameObject> TrainOn_5_line)
        {
            //
            NullWarning();
            InfAboutFlags(Flags);
            CheckTrainOnLne(TrainOn_1_line, TrainOn_2_line, TrainOn_3_line, TrainOn_4_line, TrainOn_5_line);

            // Задание задач 
            ThinkAboutCreate();
            //
        }

        private void NullWarning()
        {
            for (int i = 0; i < WarningSections.Length; i++)
            {
                WarningSections[i] = 0;
            }

            for (int i = 0; i < LevelOFWarning.Length; i++)
            {
                LevelOFWarning[i] = 0;
            }

            for (int i = 0; i < Desijion.Length; i++)
            {
                Desijion[i] = i;
            }
        }

        private void InfAboutFlags(Transform[] Flags)  // от 
        {
            for (int i = 0; i < Flags.Length; i++)
            {
                WarningSections[i] = (Convert.ToInt32(DistanceForFlags + Flags[i].position.x)) / 4;
            }
        }

        private void CheckTrainOnLne(List<GameObject> TrainOn_1_line, List<GameObject> TrainOn_2_line,
            List<GameObject> TrainOn_3_line, List<GameObject> TrainOn_4_line, List<GameObject> TrainOn_5_line)
        {
            foreach (var item in TrainOn_1_line)
            {
                CheckOfTegs(item, 0);
            }

            foreach (var item in TrainOn_2_line)
            {
                CheckOfTegs(item, 1);
            }

            foreach (var item in TrainOn_3_line)
            {
                CheckOfTegs(item, 2);
            }

            foreach (var item in TrainOn_4_line)
            {
                CheckOfTegs(item, 3);
            }

            foreach (var item in TrainOn_5_line)
            {
                CheckOfTegs(item, 4);
            }
        }

        private void CheckOfTegs(GameObject Item_Obj, int Item_Obj_LineNumber)
        {
            if (Item_Obj.gameObject.tag == S_MainControls.Tag_FirstTarin_Player)
                WarningSections[Item_Obj_LineNumber] += 4;

            if (Item_Obj.gameObject.tag == S_MainControls.Tag_SecondTarin_Player)
                WarningSections[Item_Obj_LineNumber] += 5;

            if (Item_Obj.gameObject.tag == S_MainControls.Tag_FirstTarin_Enemy)
                WarningSections[Item_Obj_LineNumber] -= 4;

            if (Item_Obj.gameObject.tag == S_MainControls.Tag_SecondTarin_Enemy)
                WarningSections[Item_Obj_LineNumber] -= 5;
        }

        private void ThinkAboutCreate()
        {
            SrednieArifm = 0;

            for (int i = 0; i < WarningSections.Length; i++)
            {
                SrednieArifm += WarningSections[i];
            }

            SrednieArifm = SrednieArifm / WarningSections.Length;

            for (int i = 0; i < WarningSections.Length; i++)
            {
                LevelOFWarning[i] = (WarningSections[i] - SrednieArifm);
            }

            // Sort
            for (int i = 0; i < LevelOFWarning.Length; i++)
            {
                for (int t = 0; t < LevelOFWarning.Length; t++)
                {
                    if (LevelOFWarning[i] < LevelOFWarning[t])
                    {
                        int a = 0;
                        a = LevelOFWarning[i];
                        LevelOFWarning[i] = LevelOFWarning[t];
                        LevelOFWarning[t] = a;

                        a = Desijion[i];
                        Desijion[i] = Desijion[t];
                        Desijion[t] = a;
                    }

                }
            }
        }
    }

}
