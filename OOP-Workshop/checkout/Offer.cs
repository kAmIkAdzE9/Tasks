using System;

namespace OOP_Workshop {
    public abstract class Offer {
        DateTime expiration;
        DateTime defaultExpiration = DateTime.Now.AddYears(1);

        internal void setExpiration(DateTime expiration) {
            this.expiration = expiration;
            this.defaultExpiration = DateTime.Now.AddYears(1);
        }

        internal DateTime getExpiration() {
            return expiration;
        }

        internal void setDefaultExpiration(DateTime expiration) {
            this.expiration = expiration;
            this.defaultExpiration = DateTime.Now.AddYears(1);
        }

        internal DateTime getDefaultExpiration() {
            return defaultExpiration;
        }

        public Offer() {
            expiration = defaultExpiration;
        }

        public Offer(DateTime expiration) {
            this.expiration = expiration;
        }

        public abstract void aplly(Check check);

        public bool checkExpiration() {
            return DateTime.Now < expiration;
        }
    }
}