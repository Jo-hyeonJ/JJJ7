using System;
using System.Threading.Tasks.Dataflow;

namespace JJJ7
{
    // C#은 클래스 밖에선 무엇도 불가능하다.

    internal class Program
    {
        // 클래스의 정의 -> 정의만으로는 실체가 존재하지 않는다.
        class Cat
        {                       // (멤버변수)
            public string name; // 이름
            public int age;     // 나이

            // 생성자 : 객체가 생성되면서 호출되는 초기화 함수.
            public Cat(string _name, int _age)
            {
                // this 키워드 : 클래스 자신을 가리키는 키워드 (매개 변수x)
                // this.name : 클래스의 멤버변수 name을 지칭한다.
                name = _name;
                age = _age;

            }
            public void ShowInfo()
            {
                Console.WriteLine($"{name}는 {age}이다.");
            }
        }
        class Phone
        {
            public enum AGENCY
            {
                SKT,
                KT,
                LG,
            }
            // 접근 제한자
            // public : 외부에 공개하겠다.
            // private : 외부에 공개하지 않겠다. (미설정시 기본 값)
            // protected : 상속 관계에서만 공개하겠다.

            public string name;
            public AGENCY Label;
            public int P_num;
            public int Y_production;
            int acsses;

            public void ShowInfo()
            {
                Console.WriteLine($"기종 : {name}");
                Console.WriteLine($"제작사 : {Label}");
                Console.WriteLine($"전화번호 : {P_num}");
                Console.WriteLine($"제작년도 : {Y_production}");
            }
            public Phone(string _name, AGENCY _Label, int _P_num, int _Y_production)
            {
                name = _name;
                Label = _Label;
                P_num = _P_num;
                Y_production = _Y_production;
            }

            public void ChangeAgency(AGENCY agency)
            {
                if (Label == agency)
                {
                    Console.WriteLine($"같은 통신사로 변경은 불가능합니다.");
                }
                else
                {
                    Label = agency;
                    Console.WriteLine($"{agency}로 통신사 변경");
                }

                /*
                if (_Label == "SKT" || _Label == "KT" || _Label == "LG")
                {
                    Console.WriteLine($"통신사 변경 : {_Label}");
                    Label = _Label;
                }
                else if (_Label == Label)
                {
                    Console.WriteLine($"같은 통신사로 변경은 불가능합니다.");
                }
                else
                {
                    Console.WriteLine($"존재하지 않는 통신사");
                }
*/
            }

            }

        class Box
        {
            public int number;

            public Box GetCopy()
            {
                Box copy = new Box(); // Box 객체를 새로 생성
                copy.number = number;

                return copy;
            }
        }

        // 플레이어

        class Character
        {
            public enum JOB
            {
                Warrior,
                Archor
            }



                // 변수에는 get과 set 기능이 존재한다.
                // get은 외부로 값을 전송 할 때
                // set은 외부에서 값을 전달 받을 때
                // 재정의하는 것으로 일부 기능을 제한 시킬수있다.
                
            int hp
            { // 프로퍼티 기본형
                get;
                set;
            }
            string name;
            JOB job;
            int mp;
            public int power // 본디 겟과 셋을 가지고 있다.
                // 자동 프로퍼티의 접근 제한자 사용. 일부 기능만을 제한시킬수 있다.
            {
                get;            // power변수의 get 기능은 public이다.
                private set;    // power 변수의 set기능은 private이다.
            }
            int defence;

            // getter, setter, 프로퍼티
            // 외부에서 읽을 수는 있지만 변경 할 수는 없게

            public int Power
            {
                // 앞으로 power라는 변수의 getter는 아래와 같이 작동하라
                // power라는 변수에 get을 재정의 했다.
                // set을 정의하지 않으면 읽기 전용(read-only) 프로퍼티가 된다.
                get
                { 
                    return power;
                }
                private set // 더이상 대입 받을 수 없는 읽기 전용 함수. (아에 삭제해도 됨)
                {
                    power = value;
                }
            }

            // 함수를 이용해서 power의 값을 외부로 전달할 수 있지만 프로퍼티가 더 편리함
            public int Getpower()
            {
                return power;
            }
            public Character(string _name, JOB _job)
            {
                name = _name;
                job = _job;
                switch(job)
                {
                    case JOB.Warrior:
                        hp = 100;
                        mp = 0;
                        power = 20;
                        defence = 10;
                        break;
                    case JOB.Archor:
                        hp = 80;
                        mp = 0;
                        power = 20;
                        defence = 10;
                        break ;


                }
            }
            public void Damage(Character attacker)
            {
                if (hp <= 0)
                {
                    Console.WriteLine("죽었다.");
                    return;
                }

                // 다른 인스턴스라도 캐릭터 클래스 내부이기 때문에 private에 접근이 가능하다.
                hp -= attacker.power;
                if (hp < 0) // 음수 막기
                {
                    hp = 0;
                }

                Console.WriteLine($"{name}이(가) {attacker.power}만큼의 데미지를 받았다.");
                Console.WriteLine($"남은 체력은 {hp}이다.");


            }
            /* 매개변수 변경 전
            public void Damage(int power)
            {
                if(hp <= 0)
                {
                    Console.WriteLine("죽었다.");
                    return;
                }

                hp -= power;
                if (hp < 0) // 음수 막기
                {
                    hp = 0;
                }

                Console.WriteLine($"{name}이(가) {power}만큼의 데미지를 받았다.");
                Console.WriteLine($"남은 체력은 {hp}이다.");


            }*/

            
        }


        static void Main(string[] args)
        {
            // 1교시 & 2교시
            #region
            /*   
               // 클래스 (class)
               // = 현실에 존재하는 모든 사물을 표현하는 방법 /= 객체
               // 사람, 사물 등의 '객체'를 생성할 수 있다.
               // 내부적으로 변수와 함수를 가지고 있다.

               // + 초기화를 해주지 않으면 C#기본형

               int a = 30; // int는 클래스이며 a는 실체(Instance)이다. a는 변수임과 동시에 객체이다.

               // new : 객체를 생성하는 연산자
               // Cat() : 생성자. 객체를 만들 때 호출되는 함수.

           // 클래스 명 + 변수명 = new 클래스 명
               // 클래스는 정의만으로 존재하지 않는다. 생성자를 호출할 때 실제 객체가 탄생한다.
               Cat cat = new Cat("나비", 3);
               cat.age = 3;
               cat.name = "고양이";

               Cat cat2 = new Cat("고양",2);
               cat2.name = "검은 고양이";
               cat2.age = 1;

               Console.WriteLine($"{cat.name}는 {cat.age}살 입니다.");
               Console.WriteLine($"{cat2.name}는 {cat2.age}살 입니다.");
               cat.ShowInfo();

               // Q. 휴대폰이라는 클래스를 만들어보자.
               // 멤버변수로는 기종, 전화번호, 통신사, 제작년도
               // 멤버함수로는 정보 출력이 있다.

               Phone phone = new Phone("A3", "LG", 55551111, 2020);

               phone.ShowInfo();

               // phone.acsses = 10; 접근제한자로 인해 변경 불가능

               phone.ChangeAgency("SKT"); // 통신사 변경 함수 사용
               phone.ShowInfo();

               Box box1 = new Box();
               box1.number = 100;

               Box box2 = box1; // box2 변수에 box1 객체를 대입. 얕은 복사
               box2.number = 200;

               Console.WriteLine();
               Console.WriteLine("얕은 복사");
               Console.WriteLine("box1 : " + box1.number);
               Console.WriteLine("box2 : " + box2.number);



               Box box3 = box1.GetCopy(); // 깊은 복사

               box1.number = 100;
               box3.number = 300;

               Console.WriteLine();
               Console.WriteLine("깊은 복사");
               Console.WriteLine("box1 : " + box1.number);
               Console.WriteLine("box3 : " + box3.number);
               */
            #endregion

            // 변수명을 짓는 방법 (coding-style)
            // 1. 변수명은 첫 시작이 소문자.
            // 2. 클래스와 함수명은 첫 시작이 대문자.
            // 3. 상수는 모두 대문자로 사용한다. (띄어쓰기로 구분이 필요한 경우 _사용)
            // 4. 띄어쓰기는 대문자로 구분한다.

            Character player = new Character("전사A", Character.JOB.Warrior);
            Character enemy = new Character("적A", Character.JOB.Warrior);

            // 플레이어가 적에게 공격을 받았다.
            player.Damage(enemy);
            // enemy.power = 20; set을 private로 만들었기 때문에 외부에서 접근이 되지 않는다.


        }
    }
}
