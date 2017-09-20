﻿using ObserverPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Subject
{
    /// <summary>
    /// 一只神奇的猫
    /// 
    /// 猫叫一声之后触发
    /// baby cry
    /// brother turn
    /// dog wang
    /// father roar
    /// mother whisper
    /// mouse run
    /// neighbor awake
    /// stealer hide
    /// 
    /// 耦合
    /// 依赖
    /// 违背单一职责
    /// 不稳定:增/减/调整顺序   都需要修改
    /// </summary>
    public class Cat
    {
        public void Miao()
        {
            Console.WriteLine("{0} Miao.....", this.GetType().Name);

            new Mouse().Run();

            new Chicken().Woo();

            new Baby().Cry(5);
            new Brother().Turn();
            new Dog().Wang();
            new Father().Roar();
            new Mother().Whisper();
            //new Mouse().Run();
            new Neighbor().Awake();
            //new Stealer().Hide();
        }



        private List<IObserver> _ObserverList = new List<IObserver>();
        public void Add(IObserver observer)
        {
            this._ObserverList.Add(observer);
        }

        public void MiaoObserver()
        {
            Console.WriteLine("{0} MiaoObserver.....", this.GetType().Name);
            //执行一系列动作   但是又不耦合
            //交给别人来指定
            //我需要接收

            foreach (var observer in this._ObserverList)
            {
                observer.Action();
            }
        }


        public event Action MiaoHandler;
        public void MiaoEvent()
        {
            Console.WriteLine("{0} MiaoObserver.....", this.GetType().Name);
            if (MiaoHandler != null)
                this.MiaoHandler();
            //foreach (Action act in this.MiaoHandler.GetInvocationList())
            //{
            //    act.Invoke();
            //}

            //MiaoHandler = null;//清除
        }
    }
}
