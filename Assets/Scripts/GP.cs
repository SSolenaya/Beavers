    public class GP {

        public static float timeBetweenPortions; // промежуток времени между появлением порций бобров, в ТЗ - K 
        public static int entitiesInPortion; // количество бобров в порции - одновременно появляются на экране, в ТЗ - N

    
        public static float delayEntityOnField; // задержка бобра на экране, в ТЗ - M

        public static float complicationGameplayWithTime; // изменение К и M со временем игры - усложнение геймплея,
        public static int timeToChangeN; // промежуток времени для усложнения геймплея, секунды (меняется параметр entitiesInPortion)
        public static int timeToChangeKM = 60; // промежуток времени для усложнения геймплея, секунды (меняется параметр timeBetweenPortions и delayEntityOnField)
        public static int pointsForBeaver; // очки за правильное действие с бобром
        public static float coefSeries; // множитель очков за успешную серию действий игрока
        public static float deltaCoefSeries; // изменение коэф за серию с каждым последующим верным действием

        public static int numOfLives = 3; //количество жизней игрока = 3
    }
