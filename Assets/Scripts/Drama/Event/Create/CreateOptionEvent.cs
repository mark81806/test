﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DramaEvent
{
    public class CreateOptionEvent : BaseDramaEvent 
    {
        private const string OptionPath = "Drama/Button";
        public string optiontext;
        public CreateOptionEvent(string options)
        {
            this.optiontext = options;
        }
        public override IEnumerator Play()
        {
            Transform buttons = StoryManager.self.ssm.Buttons.Find("Buttons");
            string[] a = optiontext.Split(new string[] { "。" }, System.StringSplitOptions.RemoveEmptyEntries);
            Button optionBtn = GameObject.Instantiate(Resources.Load<Button>($"Prefabs/{OptionPath}"));
            //optionBtn.transform.SetParent(buttons.transform);

            optionBtn.onClick.AddListener(delegate() { astro(1); }); //要加delegate?
            optionBtn.onClick.AddListener(delegate() { astro(2); }); //要加delegate?
            
            yield return null;
        }

        void astro(int choice)
        {
            PlayerData.self.Choice = choice;
        }
    }
}