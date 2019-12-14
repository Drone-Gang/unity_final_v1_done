/*
© CentraleSupelec, 2017
Author: Dr. Jeremy Fix (jeremy.fix@centralesupelec.fr)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

// Adjustments to new Publication Timing and Execution Framework
// © Siemens AG, 2018, Dr. Martin Bischoff (martin.bischoff@siemens.com)

using UnityEngine;
using System.Collections;


namespace RosSharp.RosBridgeClient
{
    public class ArrowSubscriber : Subscriber<Messages.Geometry.PoseStamped>
    {

        public GameObject[] arrows;
        int data;

        bool isMessageReceived = false;

        protected override void Start()
        {
            base.Start();
        }

        protected override void ReceiveMessage(Messages.Geometry.PoseStamped message)
        {
            data = (int)message.pose.position.x;
            isMessageReceived = true;
        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        private void ProcessMessage()
        {
            ResetArrows();
            if(data >= 0)
                arrows[data].SetActive(true);
            isMessageReceived = false;
        }

        private void ResetArrows()
        {
            for(int i = 0; i < arrows.Length; i++) {
                arrows[i].SetActive(false);
            }
        }
    }
}