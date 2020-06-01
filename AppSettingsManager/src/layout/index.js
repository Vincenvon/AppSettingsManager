import React from 'react';
import * as S from './styled';
import { Settings } from 'root/pages';

const Layout = () => {
    return (
        <S.Main>
            <S.HeaderContainer>
                <S.Title>Application Settings Manager</S.Title>
            </S.HeaderContainer>
            <S.ContentContainer>
                <Settings />
            </S.ContentContainer>
        </S.Main>
    );
}

export default Layout;