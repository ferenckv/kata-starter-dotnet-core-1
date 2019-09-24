import {Car} from "./Car";
import {Motorcycle} from "./Motorcycle";
import {Bus} from "./Bus";
import {Helicopter} from "./Helicopter";

interface IVehicleConfig {
    spaces: number;
    basePrice: number;
}

export class ParkingLot {
    constructor(public spaces: number) {

    }

    charge(vehicle: Vehicle, durationDays: number) {

        // const calculator = priceCalculatorFactory.create(vehicle, durationDays);
        // return calculator.calculate();
        
        function getVehicleConfig(vehicle: Vehicle) : IVehicleConfig  {
            switch(vehicle.constructor){
                case Car:
                    return { spaces: 1, basePrice: 5 };
                case Motorcycle:
                    return { spaces: .5, basePrice: 3 };
                case Bus:
                    return { spaces: 2, basePrice: 9};
                case Helicopter: 
                    return { spaces: 8, basePrice: 35};
                default:
                    return { spaces: 0, basePrice: 0 };                    
            }
        }

        const config = getVehicleConfig(vehicle);

        if (this.spaces < config.spaces) throw new Error("rejected");

        this.spaces -= config.spaces;
        let total = config.basePrice * durationDays;

        if(durationDays >= 6){
            total = total * .7;
        }
        else if(durationDays >= 3){
            total = total * .8;
        }
        
        if (vehicle.isElectric) {
            total = total * .5;
        }
        
        if(vehicle.sticker === "trump")
        {
            total = total * 2;
        }
        
        return total;
    }
}