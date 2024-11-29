import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {TokenService} from './token.service';

export interface LogInResponse {
  token: string
}

export interface LogInRequest {
  email: string,
  password: string
}

export interface ErrorModel {
  message: string
}

export interface RegisterRequest {
  email: string,
  password: string,
  name: string,
  address: string,
  phoneNumber: string
  role: number
}

export interface PurchaseRequest {
  id: number,
  productName: string,
  productCount: number,
  cost: number,
  buyerId: number
}

export interface PurchaseResponse {
  id: number,
  purchaseRequestId: number,
  cost: number,
  comment: string
}

export interface CreatePurchaseResponseDto {
  purchaseRequestId: number,
  cost: number,
  comment: string
}

export interface CreatePurchaseRequestDto {
  productName: string,
  productCount: number,
  cost: number
}



@Injectable({providedIn: "root"})
export class HttpService {

  constructor(private http: HttpClient, private tokenService: TokenService) {
  }

  baseurl: string = "http://localhost:5141"

  logIn(logInRequest: LogInRequest): Observable<LogInResponse> {
    const url: string = `${this.baseurl}/Auth/LogIn`
    return this.http.post<LogInResponse>(url, logInRequest)
  }

  register(value: RegisterRequest): Observable<void> {
    const url: string = `${this.baseurl}/Register/Register`
    return this.http.post<void>(url, value)

  }

  getAllPurchaseRequests(): Observable<PurchaseRequest[]> {
    const url: string = `${this.baseurl}/PurchaseRequest/GetAllPurchaseRequests`
    return this.http.get<PurchaseRequest[]>(url)
  }

  getPurchaseRequestsByBuyerId(id: number): Observable<PurchaseRequest[]> {
    const url: string = `${this.baseurl}/PurchaseRequest/GetPurchaseRequestByBuyerId`
    return this.http.get<PurchaseRequest[]>(url, {
      params: {
        buyerId: id
      }
    })
  }

  createPurchaseResponse(request: CreatePurchaseResponseDto): Observable<void> {
    const url: string = `${this.baseurl}/PurchaseResponse/CreatePurchaseResponse`;
    return this.http.post<void>(url, request)
  }

  getPurchaseResponsesByBuyerId(id: number): Observable<PurchaseResponse[]> {
    const url: string = `${this.baseurl}/PurchaseResponse/GetPurchaseResponsesByBuyerId`
    return this.http.get<PurchaseResponse[]>(url,{
      params: {
        buyerId: id
      }
    })
  }

  createPurchaseRequest(value: CreatePurchaseRequestDto):Observable<void> {
    const url: string = `${this.baseurl}/PurchaseRequest/CreatePurchaseRequest`
    return this.http.post<void>(url, value)
  }

  deletePurchaseRequest(purchaseRequestId: number):Observable<void> {
    const url: string = `${this.baseurl}/PurchaseRequest/DeletePurchaseRequest`;
    return this.http.delete<void>(url,{
      params: {
        purchaseRequestId: purchaseRequestId
      }
    });
  }
}
