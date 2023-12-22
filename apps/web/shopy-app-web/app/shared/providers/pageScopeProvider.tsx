'use client';

import { useCheckUser } from "@/app/auth/shared/authApi";
import { usePathname, useRouter } from "next/navigation";
import React, { PropsWithChildren } from 'react';
import { RoutesPaths, ScopeType, routesConfig } from "@/app/routes";

const PageScopeProvider = ({ children }: PropsWithChildren) => {
    const router = useRouter();
    const route = usePathname();
    const { isSuccess, isError, isLoading } = useCheckUser();

    const { scope } = routesConfig[route as RoutesPaths];
   
    
    if (isLoading) return null;

    if (scope === ScopeType.PUBLIC && isSuccess) {
        router.push(RoutesPaths.ProductList);
    }

    if (scope === ScopeType.PRIVATE && isError) {
        router.push(RoutesPaths.Login);
    }

    return (
        <>
            {children}
        </>
    );
};

export default PageScopeProvider;