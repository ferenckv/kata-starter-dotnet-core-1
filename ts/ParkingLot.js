"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const Car_1 = require("./Car");
const Motorcycle_1 = require("./Motorcycle");
const Bus_1 = require("./Bus");
const Helicopter_1 = require("./Helicopter");
class ParkingLot {
    constructor(spaces) {
        this.spaces = spaces;
    }
    charge(vehicle, durationDays) {
        // const calculator = priceCalculatorFactory.create(vehicle, durationDays);
        // return calculator.calculate();
        function getVehicleConfig(vehicle) {
            if (vehicle instanceof Car_1.Car) {
                return { spaces: 1, price: 5 };
            }
            if (vehicle instanceof Motorcycle_1.Motorcycle) {
                return { spaces: .5, price: 3 };
            }
            if (vehicle instanceof Bus_1.Bus) {
                return { spaces: 2, price: 9 };
            }
            if (vehicle instanceof Helicopter_1.Helicopter) {
                return { spaces: 8, price: 35 };
            }
            return { spaces: 0, price: 0 };
        }
        const config = getVehicleConfig(vehicle);
        if (this.spaces < config.spaces)
            throw new Error("rejected");
        this.spaces -= config.spaces;
        let total = config.price * durationDays;
        if (durationDays >= 6) {
            total = total * .7;
        }
        else if (durationDays >= 3) {
            total = total * .8;
        }
        if (vehicle.isElectric) {
            total = total * .5;
        }
        if (vehicle.sticker === "trump") {
            total = total * 2;
        }
        return total;
    }
}
exports.ParkingLot = ParkingLot;
