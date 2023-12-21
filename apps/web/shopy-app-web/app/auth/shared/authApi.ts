import apiClient from "@/app/shared/api/axios.client"
import { useMutation } from "@tanstack/react-query";


export function useRegister<T>(){
    const register = (data: T) => {
        return apiClient.post("auth/register", data)
    }
    
    return useMutation({
        mutationFn: register
    })
}

export function useLogin<T>(){
    const login = (data: T) => {
        return apiClient.post("auth/login", data)
    }

    return useMutation({
        mutationFn: login,
        onSuccess: (response: {data: {token: string}}) => {
            localStorage.setItem("access_token", response.data.token)
        },
    })
}