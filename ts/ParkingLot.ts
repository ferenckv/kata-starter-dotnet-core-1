export class ParkingLot {
    constructor(public spaces: number) {

    }

    charge(vehicle: Vehicle, durationDays: number) {
        if (this.spaces < vehicle.spaces) throw new Error("rejected");

        this.spaces -= vehicle.spaces;
        let total = vehicle.normalPrice * durationDays;

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