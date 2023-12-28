'use client';

import { useCheckUser } from "@/app/auth/shared/authApi";
import { usePathname, useRouter } from "next/navigation";
import React, { PropsWithChildren } from 'react';
import { RoutesPaths, ScopeType, routesConfig } from "@/app/routes";

const PageScopeProvider = ({ children }: { children: any }): JSX.Element => {
    const router = useRouter();
    const route = usePathname();
    const { isSuccess, isError, isLoading } = useCheckUser();

    const { scope } = routesConfig[route as RoutesPaths];
   
    
    if (isLoading) return <></>;

    if (scope === ScopeType.PUBLIC && isSuccess) {
        router.push(RoutesPaths.ProductList);
        router.refresh();
    }

    if (scope === ScopeType.PRIVATE && isError) {
        router.push(RoutesPaths.Login);
        router.refresh();
    }

    return (
        <>
            {children}
        </>
    );
};

export default PageScopeProvider;