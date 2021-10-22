using System;

namespace OOP_Workshop
{
    public abstract class Offer
    {
        DateTime expiration;
        DateTime defaultExpiration = DateTime.Now.AddYears(1);

        internal void setExpiration(DateTime expiration)
        {
            this.expiration = expiration;
            this.defaultExpiration = DateTime.Now.AddYears(1);
        }

        internal DateTime getExpiration()
        {
            return expiration;
        }

        internal void setDefaultExpiration(DateTime expiration)
        {
            this.expiration = expiration;
            this.defaultExpiration = DateTime.Now.AddYears(1);
        }

        internal DateTime getDefaultExpiration()
        {
            return defaultExpiration;
        }

        public Offer()
        {
            expiration = defaultExpiration;
        }

        public Offer(DateTime expiration)
        {
            this.expiration = expiration;
        }

        public void apply(Check check) {
            if(checkExpiration() && checkCondition(check)) {
                addPoints(check, calculatePoints(check));
            }
        }

        protected void addPoints(Check check, int points)
        {
            check.addPoints(points);
        }
        
        protected virtual int calculatePoints(Check check) {
            return check.getTotalCost();
        }

        protected virtual bool checkCondition(Check check)
        {
            return true;
        }

        protected bool checkExpiration()
        {
            return DateTime.Now < expiration;
        }
    }
}