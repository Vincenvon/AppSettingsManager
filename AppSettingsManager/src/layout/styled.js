import styled from 'styled-components';

export const Main = styled.div`
    height: 100vh;
    width: 100vw;
`;

export const HeaderContainer = styled.div`
    height: 60px;
    background-color: #d4d4d4;
    display:flex;
    align-items: center;
    padding-left: 10%;
`;

export const ContentContainer = styled.div`
    height: calc(100% - 60px);
`;

export const Title = styled.h2`
    margin: 0;
    color: white;
`;