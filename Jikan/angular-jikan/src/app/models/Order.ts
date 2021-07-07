import { OrderDetail } from "./OrderDetail";

export interface Order {
    id? : number;
    total : number;
    date : Date;
    deliveryAddress : string;
    orderDetails : OrderDetail[];
    name : string;
    email : string;
    city: string;
    postalCode : number;
}