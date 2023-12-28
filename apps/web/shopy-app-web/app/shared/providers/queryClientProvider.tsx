'use client';

import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import React from 'react';
import { PropsWithChildren } from 'react';

const queryClient = new QueryClient();

const QueryProvider = ({ children }: { children: any }) => {
    return (
        <QueryClientProvider client={queryClient}>
            {children}
        </QueryClientProvider>
    );
};

export default QueryProvider;