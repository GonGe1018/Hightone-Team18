using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gunggme
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private int _hp;
        public int HP => _hp;

        public void SetHP(int hp)
        {
            _hp = hp;
        }

        /// <summary>
        /// 데미지를 입고 죽었는지 안죽었는지 확인
        /// </summary>
        /// <param name="dmg">입는 데미지 피해</param>
        /// <returns>죽었는지 안죽었는지 확인</returns>
        public bool isDamaged(int dmg)
        {
            _hp -= dmg;

            if (_hp <= 0)
            {
                _hp = 0;
                return true;
            }
            
            return false;
        }
    }
}
