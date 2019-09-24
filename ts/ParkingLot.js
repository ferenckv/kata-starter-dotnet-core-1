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
            switch (vehicle.constructor) {
                case Car_1.Car:
                    return { spaces: 1, basePrice: 5 };
                case Motorcycle_1.Motorcycle:
                    return { spaces: .5, basePrice: 3 };
                case Bus_1.Bus:
                    return { spaces: 2, basePrice: 9 };
                case Helicopter_1.Helicopter:
                    return { spaces: 8, basePrice: 35 };
                default:
                    return { spaces: 0, basePrice: 0 };
            }
        }
        const config = getVehicleConfig(vehicle);
        if (this.spaces < config.spaces)
            throw new Error("rejected");
        this.spaces -= config.spaces;
        let total = config.basePrice * durationDays;
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
        if (vehicle instanceof Bus_1.Bus && vehicle.isElectric && durationDays >= 10) {
            total = 20;
        }
        return total;
    }
}
exports.ParkingLot = ParkingLot;
