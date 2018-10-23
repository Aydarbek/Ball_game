using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls
{
    class Game
    {
        int max = 9;
        int[,] map; // 0 - пусто, 1-6 - шарик цвета N.
        Status status;
        Ball[] ball = new Ball[3];
        static Random rand = new Random();
        int max_colors = 6;


        ShowItem Show;
        enum Status
        {
            init,           //Самое начало
            wait,           //ожидание выбора первого шарика
            ball_mark,      //шарик выбран-отмечен, ожидаем выбор точки В
            path_show,      //Показать путь следования шарика
            ball_move,      //перемещение шарика
            next_balls,     //вывод подсказки по следующим шарикам
            line_strip,     //"взрыв" собранных линий
            stop            //поле заполнено, конец игры
        }



        public Game (int max, ShowItem Show)
        {
            this.max = max;
            map = new int[max, max];
            this.Show = Show;
            status = Status.init;
        }
        
        public void ClickBox(int x, int y)
        {

        }

        public void Step()
        {
            switch (status)
            {
                case Status.init:
                    SelectNextBalls();
                    ShowNextBalls();
                    status = Status.wait;
                    break;

                case Status.wait:
                    break;

                case Status.ball_mark:
                    JumpBall();
                    break;

                case Status.path_show:
                    break;

                case Status.ball_move:
                    MoveBall();
                    break;

                case Status.next_balls:
                    ShowNextBalls();
                    break;

                case Status.line_strip:
                    StripLines();
                    break;


            }
        }

        
        private void SelectNextBalls()
        {
            ball[0] = SelectNextBall();
            ball[1] = SelectNextBall();
            ball[2] = SelectNextBall();
            
        }

        private Ball SelectNextBall()
        {
            int loop = 100;
            Ball next;
            next.color = rand.Next(0, max_colors + 1);
            do
            {
                next.x = rand.Next(0, max);
                next.y = rand.Next(0, max);
                if (--loop < 0)
                {
                    next.x = -1;
                    return next;
                }
            } while (map[next.x, next.y] != 0);
            map[next.x, next.y] = -1;
            Show(next, Item.next);
            return next;

        }

        private void ShowNextBalls()
        {

        }

        private void JumpBall()
        {

        }

        private void MoveBall()
        {

        }

        private void StripLines()
        {

        }
            
    }
}
