import {Car} from "./Car";
import {Motorcycle} from "./Motorcycle";
import {Bus} from "./Bus";
import {Helicopter} from "./Helicopter";

interface IVehicleConfig {
    spaces: number;
    price: number;
}

export class ParkingLot {
    constructor(public spaces: number) {

    }

    charge(vehicle: Vehicle, durationDays: number) {

        // const calculator = priceCalculatorFactory.create(vehicle, durationDays);
        // return calculator.calculate();
        
        function getVehicleConfig(vehicle: Vehicle) : IVehicleConfig  {
            if(vehicle instanceof Car){
                return { spaces: 1, price: 5 };
            }
            if(vehicle instanceof Motorcycle){
                return { spaces: .5, price: 3 };
            }
            if(vehicle instanceof Bus){
                return { spaces: 2, price: 9};
            }
            if(vehicle instanceof Helicopter){
                return { spaces: 8, price: 35};
            }
            return { spaces: 0, price: 0 };
        }

        const config = getVehicleConfig(vehicle);

        if (this.spaces < config.spaces) throw new Error("rejected");

        this.spaces -= config.spaces;
        let total = config.price * durationDays;

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